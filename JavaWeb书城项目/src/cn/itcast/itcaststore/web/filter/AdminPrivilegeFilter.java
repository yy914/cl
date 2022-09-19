package cn.itcast.itcaststore.web.filter;

import cn.itcast.itcaststore.domain.User;

import javax.servlet.*;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;

public class AdminPrivilegeFilter implements Filter {

	public void init(FilterConfig filterConfig) throws ServletException {

	}

	public void doFilter(ServletRequest req, ServletResponse resp,
			FilterChain chain) throws IOException, ServletException {
		// 1 强制转换
		HttpServletRequest request = (HttpServletRequest) req;
		HttpServletResponse response = (HttpServletResponse) resp;

		// 2判断是否具有权限
		User user = (User) request.getSession().getAttribute("user");

		if (user != null && "超级用户".equals(user.getRole())) {
			// 3.放行
			chain.doFilter(request, response);
			return;
		}

		response.sendRedirect(request.getContextPath() + "/error/privilege.jsp");

	}

	public void destroy() {

	}

}
